<?php
function CheckMonth($month)
{
    switch ($month)
    {
        case "January":
            return "'2020-01-01' AND '2020-01-31'";
        case "February":
            return "'2020-02-01' AND '2020-02-29'";
        case "March":
            return "'2020-03-01' AND '2020-03-31'";
        case "April":
            return "'2020-04-01' AND '2020-04-30'";
        case "May":
            return "'2020-05-01' AND '2020-05-31'";
        case "June":
            return "'2020-06-01' AND '2020-06-30'";
        case "July":
            return "'2020-07-01' AND '2020-07-31'";
            case "August":
            return "'2020-08-01' AND '2020-08-31'";
        case "September":
            return "'2020-09-01' AND '2020-09-30'";
        case "October":
            return "'2020-10-01' AND '2020-10-31'";
        case "November":
            return "'2020-11-01' AND '2020-11-30'";
        case "December":
            return "'2020-12-01' AND '2020-12-31'";
        default:
            return "failed to get range";
    }
}

function buildQuery($tbl)
{
    $range = checkMonth($_SESSION["selectMonthsGlobal"]);
    //debug_to_console($_SESSION["selectMonthsGlobal"]);
    $departmentName = $_SESSION['department'];
    $sql = "SELECT date FROM $tbl WHERE $departmentName = :employeeName AND date BETWEEN $range";
    return $sql;
}

function GetMorningDates()
{
    $employeeName = $_SESSION['id'];
    $servername = "studmysql01.fhict.local";
    $database = 'dbi400999';
    $username = "dbi400999";
    $password = "Group6Project";
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $sql = buildQuery('morningshifts');
    $stmt = $conn->prepare($sql);
    $stmt->execute(
        [
            ':employeeName'=> $employeeName,
        ]
    );
    $data = $stmt->fetchAll();

    return $data;
}
function GetAfternoonDates()
{
    $employeeName = $_SESSION['id'];
    $servername = "studmysql01.fhict.local";
    $database = 'dbi400999';
    $username = "dbi400999";
    $password = "Group6Project";
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $sql = buildQuery('afternoonshifts');
    $stmt = $conn->prepare($sql);
    $stmt->execute(
        [
            ':employeeName'=> $employeeName,
        ]
    );
    $data = $stmt->fetchAll();

    return $data;
}

function GetEveningDates()
{
    $employeeName = $_SESSION['id'];
    $servername = "studmysql01.fhict.local";
    $database = 'dbi400999';
    $username = "dbi400999";
    $password = "Group6Project";
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $sql = buildQuery('eveningshifts');
    $stmt = $conn->prepare($sql);
    $stmt->execute(
        [
            ':employeeName'=> $employeeName,
        ]
    );
    $data = $stmt->fetchAll();

    return $data;
}

?>