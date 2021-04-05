<?php
function cmp($a, $b) {
    return strcmp($a->date, $b->date);
}



function array_copy($arr) {
    $newArray = array();
    foreach($arr as $key => $value) {
        if(is_array($value)) $newArray[$key] = array_copy($value);
        else if(is_object($value)) $newArray[$key] = clone $value;
        else $newArray[$key] = $value;
    }
    return $newArray;
}

class ShiftDate{
    public $date;
    public $isMorning;
    public $isAfternoon;
    public $isEvening;
    private $toReturn = "";

    function __construct($date, $isMorning, $isAfternoon, $isEvening)
    {
        $this->date = $date;
        $this->isMorning = $isMorning;
        $this->isAfternoon = $isAfternoon;
        $this->isEvening = $isEvening;
        $this->toReturn = $date;
    }

    function toString(){
        if ($this->isMorning == true){
            $this->toReturn = $this->toReturn . ", Morning";
        }
        if ($this->isAfternoon == true){
            $this->toReturn = $this->toReturn . ", Afternoon";
        }
        if ($this->isEvening == true){
            $this->toReturn = $this->toReturn . ", Evening";
        }
        return $this->toReturn;
    }

    function clearToReturn(){
        $this->toReturn = $this->date;
    }
}

function CombineDates($listMornDatesTemp, $listAfternoonDates, $listEveningDates){
    $listTemporaryDates = array();
    $listTemporaryDates = array_copy($listMornDatesTemp);


    for ($i = 0; $i < count($listAfternoonDates); $i++)
    {
        $toAdd = true;
        for($j = 0; $j < count($listMornDatesTemp); $j++)
        {
            if ($listAfternoonDates[$i]->date == $listMornDatesTemp[$j]->date)
            {
                $listTemporaryDates[$j]->isAfternoon = true;
                $toAdd = false;
            }
        }
        if ($toAdd == true){
            array_push($listTemporaryDates, $listAfternoonDates[$i]);
        }
    }


    $listDatesFINAL = array();
    $listDatesFINAL = array_copy($listTemporaryDates);

    for ($i = 0; $i < count($listEveningDates); $i++){
        $toAdd = true;
        for($j = 0; $j < count ($listTemporaryDates); $j++){
            if($listEveningDates[$i]->date == $listTemporaryDates[$j]->date){
                $listDatesFINAL[$j]->isEvening = true;
                $toAdd = false;
            }
        }
        if ($toAdd == true){
            array_push($listDatesFINAL, $listEveningDates[$i]);
        }
    }
    usort($listDatesFINAL, "cmp");
    return $listDatesFINAL;
}

?>