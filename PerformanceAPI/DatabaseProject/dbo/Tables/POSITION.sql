﻿-----------------------------
--"POSITION"
-----------------------------
CREATE TABLE "POSITION" (
	"POSITION_ID" NUMERIC(6) PRIMARY KEY,
	"POSITION_NAME" VARCHAR(30) NOT NULL,
	"POSITION_DESCRIPTION" VARCHAR(200) NOT NULL,
	"POSITION_SALARY_LOWER" NUMERIC(10,2) NOT NULL,
	"POSITION_SALARY_UPPER" NUMERIC(10,2) NOT NULL
	)