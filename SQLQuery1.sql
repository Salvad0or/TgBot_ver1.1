SELECT * FROM Client c
JOIN ClientStatus cs
On c.StatusID = cs.Id
JOIN ClientBankAccout cba
on cba.ClientId = c.Id
WHERE c.Id = 15