<?php
include 'shiftDateClass.php';
session_start();
$morningShifts = $_SESSION["morningArray"];
$afternoonShifts =  $_SESSION["afternoonArray"];
$eveningShifts = $_SESSION["eveningArray"];

$morningShiftsObjects = array();
$afternoonShiftsObjects = array();
$eveningShiftsObjects = array();
$combinedShiftsObjects = array();

for ($i = 0; $i < count($morningShifts); $i++){
    array_push($morningShiftsObjects, new ShiftDate($morningShifts[$i],true, false, false));
}

for ($i = 0; $i < count($afternoonShifts); $i++){
    array_push($afternoonShiftsObjects, new ShiftDate($afternoonShifts[$i],false, true, false));
}

for ($i = 0; $i < count($eveningShifts); $i++){
    array_push($eveningShiftsObjects, new ShiftDate($eveningShifts[$i],false, false, true));
}

$combinedShiftsObjects = CombineDates($morningShiftsObjects, $afternoonShiftsObjects, $eveningShiftsObjects);
$combinedShiftsString = array();
for ($i = 0; $i < count($combinedShiftsObjects); $i++){
    array_push($combinedShiftsString,$combinedShiftsObjects[$i]->toString());
    $combinedShiftsObjects[$i]->clearToReturn();
}


$myJSON = json_encode($combinedShiftsString);
echo $myJSON;