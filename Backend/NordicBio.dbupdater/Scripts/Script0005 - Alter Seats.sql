﻿ALTER TABLE Seats
ADD [State] varchar(10) NOT NULL;

ALTER TABLE Seats
ADD ReserveTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP;

