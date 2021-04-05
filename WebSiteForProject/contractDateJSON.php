<?php
session_start();
$contractDates = $_SESSION["contractDateArray"];
$myJSON = json_encode($contractDates);
echo $myJSON;
?>