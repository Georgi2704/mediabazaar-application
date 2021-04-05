<?php
session_start();
$contractDates = $_SESSION["contractDepartmentArray"];
$myJSON = json_encode($contractDates);
echo $myJSON;
?>