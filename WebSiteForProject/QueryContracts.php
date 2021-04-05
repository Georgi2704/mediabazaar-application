<?php
function GetDateOfChange()
{
    $employeeName = $_SESSION['id'];
    $servername = "studmysql01.fhict.local";
    $database = 'dbi400999';
    $username = "dbi400999";
    $password = "Group6Project";
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $sql = "SELECT dateOfChange FROM contracts WHERE employeeID = :employeeName";
    $stmt = $conn->prepare($sql);
    $stmt->execute(
        [
            ':employeeName'=> $employeeName,
        ]
    );
    $data = $stmt->fetchAll();

    return $data;
}

function GetNewSalary()
{

    $employeeName = $_SESSION['id'];
    $servername = "studmysql01.fhict.local";
    $database = 'dbi400999';
    $username = "dbi400999";
    $password = "Group6Project";
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $sql = "SELECT newSalary FROM contracts WHERE employeeID = :employeeName";
    $stmt = $conn->prepare($sql);
    $stmt->execute(
        [
            ':employeeName'=> $employeeName,
        ]
    );
    $data = $stmt->fetchAll();

    return $data;
}

function GetNewDepartment()
{

    $employeeName = $_SESSION['id'];
    $servername = "studmysql01.fhict.local";
    $database = 'dbi400999';
    $username = "dbi400999";
    $password = "Group6Project";
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $sql = "SELECT newDepartment FROM contracts WHERE employeeID = :employeeName";
    $stmt = $conn->prepare($sql);
    $stmt->execute(
        [
            ':employeeName'=> $employeeName,
        ]
    );
    $data = $stmt->fetchAll();

    return $data;
}

function GetNewPosition()
{

    $employeeName = $_SESSION['id'];
    $servername = "studmysql01.fhict.local";
    $database = 'dbi400999';
    $username = "dbi400999";
    $password = "Group6Project";
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $sql = "SELECT newPosition FROM contracts WHERE employeeID = :employeeName";
    $stmt = $conn->prepare($sql);
    $stmt->execute(
        [
            ':employeeName'=> $employeeName,
        ]
    );
    $data = $stmt->fetchAll();

    return $data;
}

