DROP USER IF EXISTS 'balasolu';
CREATE USER 'balasolu'@'%' IDENTIFIED BY 'balasolu';
GRANT ALL PRIVILEGES ON *.* TO 'balasolu'@'%' IDENTIFIED BY 'balasolu';
FLUSH PRIVILEGES;
