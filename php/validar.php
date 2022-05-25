<?php
    require_once 'usuarios.php';
    ini_set('display_errors', 1);
    $u = new User();
    if (isset($_POST['usuario'])){
        $user = addslashes($_POST['usuario']);
        $passwd = addslashes($_POST['senha']);

        if (!empty($user) && !empty($passwd)){
            $u->conectar("teste", "127.0.0.1", $user, $passwd);
            if ($u->msgErro == ""){
                if (!$u->logar($user, $passwd)){
                    echo "Credenciais incorretas!";
                }
            } else{
                echo "Erro: " . $u->msgErro;
            }
        } else{
            echo "Preencha todos os campos obrigatórios!";
        }
    }
?>