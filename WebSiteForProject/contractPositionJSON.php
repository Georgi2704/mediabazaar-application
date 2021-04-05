<?php
session_start();
$contractDates = $_SESSION["contractPositionArray"];
$myJSON = json_encode($contractDates);
echo $myJSON;

