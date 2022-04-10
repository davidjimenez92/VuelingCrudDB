﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VuelingCrudDB.Infrastructure.Repositories {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class QueriesResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal QueriesResources() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VuelingCrudDB.Infrastructure.Repositories.QueriesResources", typeof(QueriesResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a sp_Add_Student.
        /// </summary>
        internal static string AddProcedure {
            get {
                return ResourceManager.GetString("AddProcedure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a INSERT INTO dbo.Students (Guid, Name, Surname) VALUES(@studentGuid, @studentName, @studentSurname).
        /// </summary>
        internal static string AddQuery {
            get {
                return ResourceManager.GetString("AddQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a sp_Delete_Student.
        /// </summary>
        internal static string DeleteProcedure {
            get {
                return ResourceManager.GetString("DeleteProcedure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a DELETE FROM dbo.Students WHERE Id=@Id.
        /// </summary>
        internal static string DeleteQuery {
            get {
                return ResourceManager.GetString("DeleteQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a sp_GetAll_Student.
        /// </summary>
        internal static string GetAllProcedure {
            get {
                return ResourceManager.GetString("GetAllProcedure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT * FROM dbo.Students.
        /// </summary>
        internal static string GetAllQuery {
            get {
                return ResourceManager.GetString("GetAllQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a sp_Update_Student.
        /// </summary>
        internal static string UpdateProcedure {
            get {
                return ResourceManager.GetString("UpdateProcedure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a UPDATE dbo.Students SET Name=@Name, Surname=@Surname WHERE Id=@Id.
        /// </summary>
        internal static string UpdateQuery {
            get {
                return ResourceManager.GetString("UpdateQuery", resourceCulture);
            }
        }
    }
}
