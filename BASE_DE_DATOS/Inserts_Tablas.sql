INSERT INTO EscuelasDeMusica (CodigoEscuela, NombreEscuela, DescripcionEscuela) VALUES
('MUS001', 'Escuela Beethoven', 'Formación clásica en instrumentos de cuerda'),
('MUS002', 'Escuela Mozart', 'Enfoque en teoría musical y piano'),
('MUS003', 'Escuela Vivaldi', 'Academia para jóvenes talentos en cuerdas y viento');

INSERT INTO Profesores (NombreProfesor, ApellidoProfesor, IdentificacionProfesor, EscuelaId) VALUES
('Luis', 'Ramírez', 'PROF001', 1),
('Ana', 'Torres', 'PROF002', 2),
('Carlos', 'Mejía', 'PROF003', 3);

INSERT INTO Alumnos (NombreAlumno, ApellidoAlumno, FechaNac, IdentificacionAlumno, EscuelaId) VALUES
('Laura', 'Martínez', '2010-05-12', 'ALUM001', 1),
('Pedro', 'González', '2009-08-23', 'ALUM002', 1),
('Andrea', 'López', '2011-02-14', 'ALUM003', 2),
('Jorge', 'Hernández', '2008-11-30', 'ALUM004', 3),
('María', 'Sánchez', '2010-04-22', 'ALUM005', 3);

-- Luis Ramírez (profesor 1) enseña a Laura y Pedro
INSERT INTO AlumnoProfesor (IdAlumno, IdProfesor) VALUES
(1, 1),
(2, 1);

-- Ana Torres (profesor 2) enseña a Andrea
INSERT INTO AlumnoProfesor (IdAlumno, IdProfesor) VALUES
(3, 2);

-- Carlos Mejía (profesor 3) enseña a Jorge y María
INSERT INTO AlumnoProfesor (IdAlumno, IdProfesor) VALUES
(4, 3),
(5, 3);
