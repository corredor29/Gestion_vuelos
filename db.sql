
-- 1. Países y ciudades

CREATE TABLE paises (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    codigo_iso VARCHAR(3) NOT NULL UNIQUE
);

CREATE TABLE ciudades (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    pais_id INT NOT NULL,
    FOREIGN KEY (pais_id) REFERENCES paises(id)
);


-- 2. Aerolíneas y aeropuertos

CREATE TABLE aerolineas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    codigo_iata VARCHAR(3) NOT NULL UNIQUE,
    pais_origen_id INT NOT NULL,
    activa TINYINT(1) NOT NULL DEFAULT 1,
    FOREIGN KEY (pais_origen_id) REFERENCES paises(id)
);

CREATE TABLE aeropuertos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(150) NOT NULL,
    codigo_iata VARCHAR(5) NOT NULL UNIQUE,
    ciudad_id INT NOT NULL,
    FOREIGN KEY (ciudad_id) REFERENCES ciudades(id)
);


-- 3. Tipos de documento

CREATE TABLE tipos_documento (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    codigo VARCHAR(10) NOT NULL UNIQUE
);


-- 4. Clientes (compradores)

CREATE TABLE clientes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tipo_documento_id INT NOT NULL,
    numero_documento VARCHAR(30) NOT NULL UNIQUE,
    nombres VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    FOREIGN KEY (tipo_documento_id) REFERENCES tipos_documento(id)
);


-- 5. Email / Teléfonos (N por cliente, normalizado)

CREATE TABLE dominios_email (
    id INT AUTO_INCREMENT PRIMARY KEY,
    dominio VARCHAR(100) NOT NULL UNIQUE     -- gmail.com, outlook.com, etc.
);

CREATE TABLE codigos_telefono (
    id INT AUTO_INCREMENT PRIMARY KEY,
    codigo_pais VARCHAR(5) NOT NULL UNIQUE,  -- +57, +34, etc.
    pais VARCHAR(100) NOT NULL
);

CREATE TABLE clientes_emails (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL,
    email_usuario VARCHAR(100) NOT NULL,   -- parte antes de @
    dominio_email_id INT NOT NULL,
    es_principal TINYINT(1) NOT NULL DEFAULT 0,
    FOREIGN KEY (cliente_id) REFERENCES clientes(id),
    FOREIGN KEY (dominio_email_id) REFERENCES dominios_email(id)
);

CREATE TABLE clientes_telefonos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL,
    codigo_telefono_id INT NOT NULL,
    telefono_numero VARCHAR(20) NOT NULL,  -- solo número local
    es_principal TINYINT(1) NOT NULL DEFAULT 0,
    FOREIGN KEY (cliente_id) REFERENCES clientes(id),
    FOREIGN KEY (codigo_telefono_id) REFERENCES codigos_telefono(id)
);


-- 6. Pasajeros (quien viaja)

CREATE TABLE pasajeros (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tipo_documento_id INT NOT NULL,
    numero_documento VARCHAR(30) NOT NULL,
    nombres VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    UNIQUE (tipo_documento_id, numero_documento),
    FOREIGN KEY (tipo_documento_id) REFERENCES tipos_documento(id)
);


-- 7. Vuelos y estados de vuelo

CREATE TABLE estados_vuelo (
    id INT AUTO_INCREMENT PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,   -- PROGRAMADO, CANCELADO, COMPLETADO
    descripcion VARCHAR(100) NOT NULL
);

CREATE TABLE vuelos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    codigo_vuelo VARCHAR(10) NOT NULL UNIQUE,
    aerolinea_id INT NOT NULL,
    aeropuerto_origen_id INT NOT NULL,
    aeropuerto_destino_id INT NOT NULL,
    fecha_salida DATETIME NOT NULL,
    fecha_llegada_estimada DATETIME NOT NULL,
    capacidad_total INT NOT NULL,
    asientos_disponibles INT NOT NULL,
    estado_vuelo_id INT NOT NULL,
    FOREIGN KEY (aerolinea_id) REFERENCES aerolineas(id),
    FOREIGN KEY (aeropuerto_origen_id) REFERENCES aeropuertos(id),
    FOREIGN KEY (aeropuerto_destino_id) REFERENCES aeropuertos(id),
    FOREIGN KEY (estado_vuelo_id) REFERENCES estados_vuelo(id),
    CONSTRAINT chk_capacidad_total CHECK (capacidad_total > 0),
    CONSTRAINT chk_asientos_disponibles CHECK (asientos_disponibles >= 0)
);


-- 8. Asientos por vuelo

CREATE TABLE asientos_vuelo (
    id INT AUTO_INCREMENT PRIMARY KEY,
    vuelo_id INT NOT NULL,
    codigo_asiento VARCHAR(5) NOT NULL,  -- 12A, 14B, etc.
    esta_ocupado TINYINT(1) NOT NULL DEFAULT 0,
    UNIQUE (vuelo_id, codigo_asiento),
    FOREIGN KEY (vuelo_id) REFERENCES vuelos(id)
);


-- 9. Reservas y estados de reserva

CREATE TABLE estados_reserva (
    id INT AUTO_INCREMENT PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,   -- PENDIENTE, CONFIRMADA, CANCELADA
    descripcion VARCHAR(100) NOT NULL
);

CREATE TABLE reservas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL,             -- quien compra
    vuelo_id INT NOT NULL,
    fecha_reserva DATETIME NOT NULL,
    estado_reserva_id INT NOT NULL,
    valor_total DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (cliente_id) REFERENCES clientes(id),
    FOREIGN KEY (vuelo_id) REFERENCES vuelos(id),
    FOREIGN KEY (estado_reserva_id) REFERENCES estados_reserva(id),
    CONSTRAINT chk_valor_total CHECK (valor_total >= 0)
);


-- 10. Reserva - pasajero - asiento

CREATE TABLE reservas_pasajeros (
    id INT AUTO_INCREMENT PRIMARY KEY,
    reserva_id INT NOT NULL,
    pasajero_id INT NOT NULL,
    asiento_vuelo_id INT NOT NULL,
    UNIQUE (reserva_id, pasajero_id),
    UNIQUE (asiento_vuelo_id),           -- un asiento solo lo ocupa un pasajero
    FOREIGN KEY (reserva_id) REFERENCES reservas(id),
    FOREIGN KEY (pasajero_id) REFERENCES pasajeros(id),
    FOREIGN KEY (asiento_vuelo_id) REFERENCES asientos_vuelo(id)
);


-- 11. Tiquetes y estados de tiquete

CREATE TABLE estados_tiquete (
    id INT AUTO_INCREMENT PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,   -- EMITIDO, ANULADO, etc.
    descripcion VARCHAR(100) NOT NULL
);

CREATE TABLE tiquetes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    reserva_pasajero_id INT NOT NULL UNIQUE,  -- un tiquete por pasajero en la reserva
    codigo_tiquete VARCHAR(30) NOT NULL UNIQUE,
    fecha_emision DATETIME NOT NULL,
    estado_tiquete_id INT NOT NULL,
    FOREIGN KEY (reserva_pasajero_id) REFERENCES reservas_pasajeros(id),
    FOREIGN KEY (estado_tiquete_id) REFERENCES estados_tiquete(id)
);


-- 12. Pagos (estados, métodos, tarjetas)

CREATE TABLE estados_pago (
    id INT AUTO_INCREMENT PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,   -- PENDIENTE, PAGADO, RECHAZADO
    descripcion VARCHAR(100) NOT NULL
);

CREATE TABLE tipos_medio_pago (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,          -- EFECTIVO, TARJETA, TRANSFERENCIA
    codigo VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE tipos_tarjeta (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,          -- CREDITO, DEBITO, PREPAGO
    codigo VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE emisores_tarjeta (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,          -- VISA, MASTERCARD, AMEX, etc.
    codigo VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE metodos_pago (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tipo_medio_pago_id INT NOT NULL,
    tipo_tarjeta_id INT NULL,
    emisor_tarjeta_id INT NULL,
    nombre_comercial VARCHAR(50) NOT NULL, -- Ej: "Tarjeta crédito VISA"
    codigo VARCHAR(20) NOT NULL UNIQUE,
    FOREIGN KEY (tipo_medio_pago_id) REFERENCES tipos_medio_pago(id),
    FOREIGN KEY (tipo_tarjeta_id) REFERENCES tipos_tarjeta(id),
    FOREIGN KEY (emisor_tarjeta_id) REFERENCES emisores_tarjeta(id)
);

CREATE TABLE pagos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    reserva_id INT NOT NULL,
    monto DECIMAL(18,2) NOT NULL,
    fecha_pago DATETIME NOT NULL,
    estado_pago_id INT NOT NULL,
    metodo_pago_id INT NOT NULL,
    FOREIGN KEY (reserva_id) REFERENCES reservas(id),
    FOREIGN KEY (estado_pago_id) REFERENCES estados_pago(id),
    FOREIGN KEY (metodo_pago_id) REFERENCES metodos_pago(id),
    CONSTRAINT chk_monto_pago CHECK (monto >= 0)
);


-- 13. Usuarios y roles (ADMIN / CLIENTE)

CREATE TABLE roles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,       -- ADMIN, CLIENTE
    descripcion VARCHAR(150) NOT NULL
);

CREATE TABLE usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    cliente_id INT NULL UNIQUE,              -- 1 cliente ↔ 1 usuario
    activo TINYINT(1) NOT NULL DEFAULT 1,
    FOREIGN KEY (cliente_id) REFERENCES clientes(id)
);

CREATE TABLE usuarios_roles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    usuario_id INT NOT NULL,
    rol_id INT NOT NULL,
    UNIQUE (usuario_id, rol_id),
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id),
    FOREIGN KEY (rol_id) REFERENCES roles(id)
);