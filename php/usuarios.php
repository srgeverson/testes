<?php 
ini_set('display_errors', 1);
class User {
    
    private $instance;
    private $comp;
    
    function __construct() {
        $this->comp = array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8");
    }
    
    public function conectar($nomeDB, $host, $user, $password) {
        if (!isset($this->instance)) {
            try {
                $this->instance = new PDO("mysql:host=" . $host . ";dbname=" . $nomeDB . ";", $user, $pass, $this->comp);
                $this->instance->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                $this->instance->setAttribute(PDO::ATTR_ORACLE_NULLS, PDO::NULL_EMPTY_STRING);
            } catch (Exception $erro) {
                throw new Exception($erro->getMessage());
            }
        }
        return $this->instance;
    }

}
?>