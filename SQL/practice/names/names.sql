SELECT * FROM names;

INSERT INTO names (name)
VALUES ('Erik Mejia');

INSERT INTO names (name)
VALUES ('Nay'),('Jair');

UPDATE names
SET name = 'Erik'
WHERE names.id = 1;

DELETE FROM names 
WHERE names.id = 3;
