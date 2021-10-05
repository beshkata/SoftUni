USE [Geography]

--Problem 9.	*Peaks in Rila

SELECT * FROM [Mountains]

SELECT * FROM [Peaks]

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC