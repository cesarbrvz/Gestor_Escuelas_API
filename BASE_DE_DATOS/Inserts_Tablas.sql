INSERT INTO EscuelasDeMusica (CodigoEscuela, NombreEscuela, DescripcionEscuela) VALUES
('MUS001', 'Escuela Beethoven', 'Formaci�n cl�sica en instrumentos de cuerda'),
('MUS002', 'Escuela Mozart', 'Enfoque en teor�a musical y piano'),
('MUS003', 'Escuela Vivaldi', 'Academia para j�venes talentos en cuerdas y viento');

INSERT INTO Profesores (NombreProfesor, ApellidoProfesor, IdentificacionProfesor, EscuelaId) VALUES
('Luis', 'Ram�rez', 'PROF001', 1),
('Ana', 'Torres', 'PROF002', 2),
('Carlos', 'Mej�a', 'PROF003', 3);

INSERT INTO Alumnos (NombreAlumno, ApellidoAlumno, FechaNac, IdentificacionAlumno, EscuelaId) VALUES
('Laura', 'Mart�nez', '2010-05-12', 'ALUM001', 1),
('Pedro', 'Gonz�lez', '2009-08-23', 'ALUM002', 1),
('Andrea', 'L�pez', '2011-02-14', 'ALUM003', 2),
('Jorge', 'Hern�ndez', '2008-11-30', 'ALUM004', 3),
('Mar�a', 'S�nchez', '2010-04-22', 'ALUM005', 3);

-- Luis Ram�rez (profesor 1) ense�a a Laura y Pedro
INSERT INTO AlumnoProfesor (IdAlumno, IdProfesor) VALUES
(1, 1),
(2, 1);

-- Ana Torres (profesor 2) ense�a a Andrea
INSERT INTO AlumnoProfesor (IdAlumno, IdProfesor) VALUES
(3, 2);

-- Carlos Mej�a (profesor 3) ense�a a Jorge y Mar�a
INSERT INTO AlumnoProfesor (IdAlumno, IdProfesor) VALUES
(4, 3),
(5, 3);
