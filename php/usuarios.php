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
                $this->instance = new PDO("mysql:host=" . $host . ";dbname=" . $nomeDB . ";port=3306;", $user, $password, $this->comp);
                $this->instance->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                $this->instance->setAttribute(PDO::ATTR_ORACLE_NULLS, PDO::NULL_EMPTY_STRING);
            } catch (Exception $erro) {
                throw new Exception($erro->getMessage());
            }
        }
        return $this->instance;
    }

    public function logar($user, $password) {
        try {
            $query = "SELECT * FROM user WHERE name=:name; AND password = :password";
            $conexao = $this->instance;
            $statement = $conexao->prepare($query);
            $statement->bindParam(":name", $name, PDO::PARAM_STR);
            $statement->bindParam(":password", $password, PDO::PARAM_STR);
            $statement->execute();
        } catch (Exception $erro) {
            throw new Exception($erro->getMessage());
        }
        return true;
    }

}
?>