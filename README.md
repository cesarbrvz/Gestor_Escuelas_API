<h1>🎵 Gestor de Escuelas de Música 🎼</h1>

<p>Aplicación web para la gestión integral de escuelas de música, profesores y alumnos. Desarrollada con <strong>ASP.NET Core</strong>, <strong>Entity Framework Core</strong> y <strong>SQL Server</strong>, implementando un enfoque limpio mediante el patrón DAO y procedimientos almacenados.</p>

<hr />

<h2>📌 Características principales</h2>
<ul>
  <li>Gestión completa de <strong>Escuelas</strong>, <strong>Profesores</strong> y <strong>Alumnos</strong>.</li>
  <li>Asignación de <strong>alumnos a profesores</strong> y <strong>profesores a escuelas</strong>.</li>
  <li>Inscripción de alumnos a escuelas.</li>
  <li>Consultas personalizadas como: <em>"¿Qué alumnos están asignados a cierto profesor?"</em></li>
  <li>Arquitectura desacoplada: DAO + ResultOperation + SP.</li>
</ul>

<h2>🧱 Tecnologías utilizadas</h2>
<ul>
  <li>ASP.NET Core 7</li>
  <li>Entity Framework Core</li>
  <li>SQL Server</li>
  <li>ADO.NET / Stored Procedures</li>
  <li>C#</li>
  <li>RESTful API</li>
</ul>

<h2>📁 Estructura del proyecto</h2>
<pre>
GestorEscuelas/
├── CODIGO/
│   ├── Controllers/
│   ├── Data/               # DAO (Data Access Objects)
│   ├── Models/
│   └── Utils/              # Clase ResultOperation
├── BASE_DE_DATOS/
│   ├── Create_Tablas.sql
│   ├── Inserts_Tablas.sql
│   ├── sp_CrudProfesor.sql
│   ├── sp_CrudAlumno.sql
│   └── sp_ConsultasPorProfesor.sql
├── ARCHIVOS_DE_CONFIGURACION/
│   └── appsettings.json
└── README.md
</pre>

<h2>⚙️ Instalación y ejecución</h2>
<ol>
  <li>Clona el repositorio:
    <pre><code>git clone https://github.com/tuusuario/GestorEscuelasMusica.git
cd GestorEscuelasMusica</code></pre>
  </li>
  <li>Restaura los paquetes y construye el proyecto:
    <pre><code>dotnet restore
dotnet build</code></pre>
  </li>
  <li>Crea la base de datos en SQL Server usando los scripts en <code>/BASE_DE_DATOS</code>.</li>
  <li>Ajusta tu cadena de conexión en <code>appsettings.json</code>.</li>
  <li>Ejecuta el proyecto:
    <pre><code>dotnet run</code></pre>
  </li>
</ol>

<h2>📌 Endpoints principales</h2>
<table>
  <thead>
    <tr>
      <th>Recurso</th>
      <th>Método</th>
      <th>Ruta</th>
      <th>Descripción</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Escuelas</td>
      <td>GET</td>
      <td>/api/escuelas</td>
      <td>Obtener todas las escuelas</td>
    </tr>
    <tr>
      <td>Profesores</td>
      <td>POST</td>
      <td>/api/profesores</td>
      <td>Crear nuevo profesor</td>
    </tr>
    <tr>
      <td>Alumnos</td>
      <td>PUT</td>
      <td>/api/alumnos/{id}</td>
      <td>Actualizar alumno por ID</td>
    </tr>
    <tr>
      <td>Consultas</td>
      <td>GET</td>
      <td>/api/consultas/profesor/1</td>
      <td>Alumnos asignados al profesor con ID = 1</td>
    </tr>
  </tbody>
</table>

<h2>✅ Ejemplo de uso: Crear un profesor</h2>
<pre><code>POST /api/profesores
{
  "nombreProfesor": "Carlos",
  "apellidoProfesor": "Márquez",
  "identificacionProfesor": "ABC123",
  "escuelaId": 1
}
</code></pre>

<h2>🧪 ResultOperation&lt;T&gt;</h2>
<p>Estructura estándar para manejar respuestas en DAO y controladores:</p>
<pre><code>public class ResultOperation&lt;T&gt;
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public List&lt;Message&gt; Messages { get; set; }
    public TypeMessage TypeMessage { get; set; }
}
</code></pre>

<h2>👨‍💻 Autor</h2>
<p>Desarrollado por <strong>Mario Cesar Briseño Vazquez</strong><br>
📧 Contacto: <em>briseno_cesar@hotmail.com</em></p>

<h2>📄 Licencia</h2>
<p>MIT License. Libre uso con fines educativos.</p>
