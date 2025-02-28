# SplitFlow

SplitFlow es una **API REST** desarrollada en **C# .NET** que implementa **CQRS (Command Query Responsibility Segregation) con Event Sourcing**. Esta arquitectura permite separar claramente la lógica de escritura (comandos) de la de lectura (consultas), mejorando la escalabilidad, mantenibilidad y capacidad de auditoría del sistema.  

El propósito de SplitFlow es gestionar entidades clave como **Usuarios, Roles y Permisos**, asegurando un historial completo de cambios mediante **Event Sourcing** y garantizando la consistencia eventual de los datos.  

## 🚀 Características principales
- **Arquitectura basada en CQRS + Event Sourcing**  
  - Separación clara entre operaciones de lectura y escritura.  
  - Persistencia de eventos para garantizar un historial inmutable de cambios.  
  - Uso de proyecciones para consultas optimizadas en MongoDB.  
- **Persistencia híbrida con SQL Server y MongoDB**  
  - **SQL Server**: Almacena datos transaccionales.  
  - **MongoDB**: Actúa como Event Store y almacena pryecciones.  
- **MediatR para comunicación interna**  
  - Manejo de comandos, consultas y eventos de manera desacoplada.  
- **Autenticación y Autorización**  
  - Implementación de **JWT (JSON Web Tokens)** para seguridad.  
  - Gestión de roles y permisos para control de acceso.  
- **Infraestructura modular**  
  - Código organizado en múltiples proyectos para facilitar escalabilidad y mantenibilidad.  
- **Manejo avanzado de errores y logging**  
  - Implementación de logs y excepciones controladas para diagnóstico.  

---

## 🏗️ Arquitectura y Estructura del Proyecto

SplitFlow está compuesto por **5 proyectos** organizados para una correcta separación de responsabilidades:  

1. **SplitFlow.API** → Punto de entrada de la aplicación (API REST).  
2. **SplitFlow.Application** → Implementación de la lógica CQRS (Comandos, Consultas, Handlers).  
3. **SplitFlow.Domain** → Definición de entidades de dominio y eventos.  
4. **SplitFlow.Infrastructure.MongoDB** → Implementación del **Event Store** y proyecciones de lectura.  
5. **SplitFlow.Infrastructure.SqlServer** → Persistencia de datos transaccionales en SQL Server.  

Cada uno de estos proyectos cumple una función específica y permite que la aplicación sea escalable y flexible.  

En las siguientes secciones se explicará cada proyecto en detalle.  

---
