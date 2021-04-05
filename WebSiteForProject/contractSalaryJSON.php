<?php
session_start();
$contractDates = $_SESSION["contractSalaryArray"];
$myJSON = json_encode($contractDates);
echo $myJSON;
?>