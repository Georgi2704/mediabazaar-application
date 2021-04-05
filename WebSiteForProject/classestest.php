<!DOCTYPE html>
<html>
<body>

<?php
function dump($array){
    echo '<pre>';
    var_dump($array);
    echo '<pre>';
}


class Fruit {
    public $name;
    public $color;

    function __construct($name, $color) {
        $this->name = $name;
        $this ->color = $color;
    }

    function set_name($name){
        $this ->name = $name;
    }

    function get_name() {
        return $this->name;
    }
    function get_color(){
        return $this->color;
    }
}

//$apple = new Fruit("YOla", "Pink");
//echo $apple->get_name() . "<br>";
//echo $apple->get_color() . "<br>";
echo "<br>";
$listfruit = array();
$listfruit[1] = new Fruit("Kurec ", "orange");
$listfruit[2] = new Fruit("2020-01-24", "yelow");
$listfruit[3] = new Fruit("2020-01-05", "zaaa    ");

echo $listfruit[1] -> get_name();
echo "<br>";
echo $listfruit[2] -> get_color();
dump($listfruit);
echo $listfruit[1]->name;
function cmp($a, $b) {
    return strcmp($a->name, $b->name);
}

usort($listfruit, "cmp");
dump($listfruit);
?>

</body>
</html>