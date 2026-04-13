# ✈️ TODO — Sistema de Gestión de Tiquetes Aéreos

> **Proyecto:** Sistema de Gestión de Tiquetes Aéreos  
> **Stack:** C# · .NET · MySQL · Entity Framework Core · LINQ · Spectre.Console  
> **Arquitectura:** Modular (ui / application / domain / infrastructure / shared)  
> **Equipo:** Pipe 🟦 · Wen 🟨  

---

## 📋 Índice

1. Convenciones del proyecto  
2. Fase 1 — Setup inicial  
3. Fase 2 — Shared: Context, UnitOfWork, Helpers, Seeds  
4. Fase 3 — Dominio y entidades base  
5. Fase 4 — Módulo Catálogos (Países, Ciudades, Aeropuertos, Aerolíneas)  
6. Fase 5 — Módulo Identidad (Tipos documento, Clientes, Contacto, Usuarios/Roles)  
7. Fase 6 — Módulo Pasajeros  
8. Fase 7 — Módulo Vuelos y Asientos  
9. Fase 8 — Módulo Reservas + Pasajeros + Asientos  
10. Fase 9 — Módulo Tiquetes  
11. Fase 10 — Módulo Pagos  
12. Fase 11 — Reportes con LINQ  
13. Fase 12 — Navegación, login y roles  
14. Fase 13 — Testing  
15. Fase 14 — Documentación  
16. Definition of Done  
17. Checklist general

---

## 📐 Convenciones del proyecto

- Clases: `PascalCase`, interfaces `IPascalCase`  
- Nada de Spectre.Console fuera de `ui/`  
- Commits tipo: `feat(modulo): ...`, `fix(modulo): ...`, `refactor(shared): ...`

---

## 🚀 Fase 1 — Setup inicial

> Objetivo: solución, paquetes y Git listos.

### 🟦 Pipe

- [ ] Crear solución .NET y proyecto consola  
- [ ] Instalar EF Core + Pomelo, Spectre.Console  
- [ ] Crear estructura de carpetas `src/modules`, `src/shared`  
- [ ] Configurar `.gitignore`, ramas `main`/`develop`

### 🟨 Wen

- [ ] `README.md` inicial  
- [ ] `appsettings.json` con conexión MySQL  
- [ ] Configurar `Program.cs` para leer configuración  
- [ ] Documentar cómo ejecutar/migrar en local

---

## 📦 Fase 2 — Shared: Context, UnitOfWork, Helpers, Seeds

> Objetivo: base técnica común para módulos + datos iniciales (seeds).

### 🟦 Pipe — DbContext y UoW

- [ ] Implementar `AppDbContext` con todos los `DbSet<>` según el SQL  
- [ ] Configurar `OnModelCreating` con `ApplyConfigurationsFromAssembly`  
- [ ] Crear interfaz `IUnitOfWork` (Commit, Rollback, repositorios)  
- [ ] Implementar `UnitOfWork`  
- [ ] Registrar `AppDbContext` y `UnitOfWork` en DI

### 🟨 Wen — Helpers

- [ ] `ConsoleHelper`: éxito, error, advertencia, confirmaciones  
- [ ] `ValidationHelper`: textos, números, fechas, emails, teléfonos  
- [ ] `FormatHelper`: fechas, moneda, truncado de texto  

### 🚀 Seeds de datos (semillas)

> Objetivo: tener datos mínimos para que el sistema funcione sin insertar todo a mano.

#### 🟦 Pipe — Seeds de catálogos técnicos

- [ ] Crear clase `DatabaseSeeder` en `shared` (por ejemplo `shared/Seed/DatabaseSeeder.cs`)  
- [ ] Métodos para sembrar:  
  - [ ] `SeedPaises()` con al menos 2–3 países  
  - [ ] `SeedCiudades()` con algunas ciudades ligadas a esos países  
  - [ ] `SeedTiposDocumento()` (CC, TI, PAS, etc.)  
  - [ ] `SeedEstadosVuelo()` (PROGRAMADO, CANCELADO, COMPLETADO)  
  - [ ] `SeedEstadosReserva()` (PENDIENTE, CONFIRMADA, CANCELADA)  
  - [ ] `SeedEstadosTiquete()` (EMITIDO, ANULADO)  
  - [ ] `SeedEstadosPago()` (PENDIENTE, PAGADO, RECHAZADO)  
  - [ ] `SeedTiposMedioPago()` (EFECTIVO, TARJETA, TRANSFERENCIA)  
  - [ ] `SeedTiposTarjeta()` (CREDITO, DEBITO)  
  - [ ] `SeedEmisoresTarjeta()` (VISA, MASTERCARD)  
  - [ ] `SeedRoles()` (ADMIN, CLIENTE)

- [ ] Asegurar que los seeds sean idempotentes (no dupliquen datos si ya existen)

#### 🟨 Wen — Seeds de datos funcionales mínimos

- [ ] `SeedAerolineas()` con 1–2 aerolíneas de prueba  
- [ ] `SeedAeropuertos()` con algunos aeropuertos + IATA  
- [ ] `SeedUsuarios()`:  
  - [ ] Usuario ADMIN de prueba (username `admin`, password de ejemplo)  
  - [ ] Usuario CLIENTE de prueba asociado a un cliente  
- [ ] `SeedClientesDemo()` con 1–2 clientes y sus emails/teléfonos  
- [ ] `SeedVuelosDemo()` con uno o dos vuelos futuros, usando aerolíneas/aeropuertos seeded  

- [ ] Añadir llamada a `DatabaseSeeder.SeedAsync()` en `Program.cs` al inicio de la app (después de migraciones)

---

## 🏗️ Fase 3 — Dominio y entidades base

> Objetivo: entidades de dominio alineadas al modelo SQL.

### 🟦 Pipe — Dominio

- [ ] `Pais`, `Ciudad`, `Aeropuerto`, `Aerolinea`  
- [ ] `EstadoVuelo`, `Vuelo`, `AsientoVuelo`  
- [ ] `EstadoPago`, `TipoMedioPago`, `TipoTarjeta`, `EmisorTarjeta`, `MetodoPago`, `Pago`  

### 🟨 Wen — Dominio

- [ ] `TipoDocumento`, `Cliente`, `DominioEmail`, `CodigoTelefono`  
- [ ] `ClienteEmail`, `ClienteTelefono`  
- [ ] `Pasajero`  
- [ ] `EstadoReserva`, `Reserva`, `ReservaPasajero`  
- [ ] `EstadoTiquete`, `Tiquete`  
- [ ] `Rol`, `Usuario`, `UsuarioRol`

Para cada entidad:

- [ ] Crear repositorios en `domain/repositories/`  
- [ ] Mantener dominio limpio (sin EF ni Spectre)

---

## 🌍 Fase 4 — Módulo Catálogos

> Objetivo: CRUD de Países, Ciudades, Aeropuertos, Aerolíneas (ADMIN).

### 🟦 Pipe — Backend

- [ ] Entities + configurations  
- [ ] Repositorios y servicios (`ICatalogoService` por entidad)  
- [ ] Lógica de validación (códigos únicos, referencias a otras tablas)

### 🟨 Wen — UI (ADMIN)

- [ ] Menú “Catálogos” con submenús  
- [ ] Formularios de alta/edición con Spectre  
- [ ] Listados tabulares con búsqueda  
- [ ] Confirmación antes de desactivar/eliminar  

---

## 👤 Fase 5 — Identidad (Clientes + Usuarios/Roles)

> Objetivo: gestionar clientes y usuarios (login, roles).

### 🟨 Wen — Backend Clientes

- [ ] Entities + configurations para `Cliente`, `ClienteEmail`, `ClienteTelefono`  
- [ ] Servicios de negocio (`ClienteService`)  
- [ ] Uso de seeds para tipos de documento y dominios de email

### 🟦 Pipe — Backend Usuarios/Roles

- [ ] Entities + configurations para `Rol`, `Usuario`, `UsuarioRol`  
- [ ] Servicios (`UsuarioService`, `RolService`)  
- [ ] Lógica: creación de usuario desde cliente, asignación de roles  
- [ ] Uso de seeds: crear `ADMIN` y `CLIENTE`, usuario admin inicial

### UI

- 🟨 Wen  
  - [ ] Pantalla de login (Spectre Console)  
  - [ ] Validar credenciales contra `usuarios`  
- 🟦 Pipe  
  - [ ] Menú de mantenimiento de usuarios (ADMIN)  
  - [ ] Asignar/quitar roles a usuarios

---

## 🧍 Fase 6 — Módulo Pasajeros

> Objetivo: gestión de pasajeros que pueden o no ser clientes.

### 🟨 Wen — Backend

- [ ] `Pasajero` entity + repository + service  
- [ ] Validar unicidad (tipoDocumento, númeroDocumento)  

### 🟦 Pipe — UI

- [ ] Menú de pasajeros (ADMIN y/o clientes que gestionan sus viajeros frecuentes)  
- [ ] Alta/edición/búsqueda de pasajeros  
- [ ] Listado por documento/nombre  

---

## 🛫 Fase 7 — Módulo Vuelos y Asientos

> Objetivo: crear y administrar vuelos y sus asientos.

### 🟦 Pipe — Backend

- [ ] `Vuelo` + `AsientoVuelo` entities y configurations  
- [ ] Servicios:  
  - Generar asientos al crear vuelo (p.ej. A–F, filas 1–30)  
  - Actualizar disponibilidad de asientos  
  - Cambiar estado de vuelo  

### 🟨 Wen — UI (ADMIN)

- [ ] Menú “Vuelos”  
- [ ] Crear vuelo usando catálogos seeded (aerolínea, aeropuertos)  
- [ ] Ver mapa/lista de asientos por vuelo  
- [ ] Filtrar por estado y fechas  

---

## 📋 Fase 8 — Reservas + Pasajeros + Asientos

> Objetivo: flujo completo de reservas con varios pasajeros y asientos.

### 🟨 Wen — Backend

- [ ] `Reserva` + `ReservaPasajero` services  
- [ ] Lógica:  
  - Crear reserva para un cliente y vuelo  
  - Vincular pasajeros ya existentes o nuevos  
  - Asignar asientos libres (`AsientosVuelo`)  
  - Actualizar `asientos_disponibles`  
  - Manejar estados de reserva y validaciones  

### 🟦 Pipe — UI (CLIENTE)

- [ ] Menú “Mis reservas”  
- [ ] Flujo paso a paso:  
  - Buscar vuelos (usando datos seeded si no hay reales)  
  - Seleccionar vuelo  
  - Seleccionar/crear pasajeros  
  - Elegir asientos disponibles  
  - Confirmar reserva  
- [ ] Listar reservas, ver detalle, cancelar cuando aplique  

---

## 🎫 Fase 9 — Tiquetes

> Objetivo: emitir tiquetes por pasajero de reserva.

### 🟦 Pipe — Backend

- [ ] Servicio `TiqueteService`  
- [ ] Emitir tiquete para cada `ReservaPasajero` de reserva confirmada  
- [ ] Generar `codigo_tiquete` único  
- [ ] Usar estados seeded de tiquete

### 🟨 Wen — UI (CLIENTE)

- [ ] Menú “Mis tiquetes”  
- [ ] Listado de tiquetes (vuelo, pasajero, asiento, estado)  
- [ ] Mostrar detalle y código de tiquete  

---

## 💳 Fase 10 — Pagos

> Objetivo: registrar pagos de reservas con métodos normalizados.

### 🟦 Pipe — Backend

- [ ] Servicios para `Pago`  
- [ ] Validar que no se dupliquen pagos finales  
- [ ] Cambiar estado de pago y opcionalmente de reserva  
- [ ] Usar seeds de `TiposMedioPago`, `TiposTarjeta`, `EmisoresTarjeta`, `EstadosPago`

### 🟨 Wen — UI

- [ ] Flujo para pagar reservas pendientes (CLIENTE)  
- [ ] Simular pago (seleccionar método de pago seeded, monto)  
- [ ] Ver historial de pagos por reserva  
- [ ] Vista ADMIN de pagos por estado/aerolínea  

---

## 📊 Fase 11 — Reportes con LINQ

> Objetivo: consultas de negocio sobre los datos seeded + datos reales.

### 🟨 Wen — Backend

- [ ] `ReporteService` con métodos LINQ:  
  - Vuelos con mayor ocupación  
  - Vuelos disponibles  
  - Clientes con más reservas  
  - Destinos más solicitados  
  - Ingresos por aerolínea  
  - Tiquetes emitidos por rango de fechas  

### 🟦 Pipe — UI

- [ ] Menú de reportes (ADMIN)  
- [ ] Tablas bonitas con Spectre  
- [ ] Filtros de fecha, aerolínea, estado, etc.  

---

## 🔐 Fase 12 — Navegación, login y roles

> Objetivo: menú principal condicionado por rol (ADMIN / CLIENTE).

### 🟦 Pipe

- [ ] Implementar login al inicio del programa  
- [ ] Determinar roles del usuario logueado  
- [ ] Mostrar menú ADMIN o CLIENTE según corresponda  

### 🟨 Wen

- [ ] Menú ADMIN: catálogos, vuelos, reportes, usuarios  
- [ ] Menú CLIENTE: reservas, tiquetes, pagos, datos de cliente  

---

## 🧪 Fase 13 — Testing

> Objetivo: validar flujos críticos.

### 🟦 Pipe

- [ ] Tests/manual checks de reservas con asientos llenos  
- [ ] Tests de emisión de tiquetes sin pago/confirmación  
- [ ] Tests de pagos duplicados  

### 🟨 Wen

- [ ] Tests de login y acceso por rol  
- [ ] Tests de flujo completo: cliente seeded → login → reservar → pagar → tiquetes  

---

## 📝 Fase 14 — Documentación

### 🟦 Pipe

- [ ] `README.md` con explicación de seeds y cómo iniciar con datos  
- [ ] Documentar restricciones más importantes  

### 🟨 Wen

- [ ] Diagrama ER final  
- [ ] Describir módulos y flujos de consola  

---

## ✔️ Definition of Done

- [ ] Modelo de BD migrado y seeds aplicados sin errores  
- [ ] Módulo implementado en todas las capas (domain, application, infrastructure, ui)  
- [ ] Lógica de negocio separada de UI  
- [ ] Validaciones correctas  
- [ ] UI funcional con Spectre.Console  
- [ ] Cobertura básica de casos principales probada  
- [ ] Commits `feat`/`fix` apropiados  

---

## 🚀 Checklist general

- [ ] Migraciones EF Core creadas y aplicadas  
- [ ] `DatabaseSeeder` ejecutándose al inicio  
- [ ] Rol ADMIN y CLIENTE creados por seed  
- [ ] Usuario ADMIN de prueba generado por seed  
- [ ] Datos básicos de países, ciudades, aeropuertos y aerolíneas seeded  
- [ ] Aplicación usable tras `dotnet ef database update` + ejecutar
```