<?php
date_default_timezone_set("America/Fortaleza");
header("Cache-Control: no-store");
header("Content-Type: text/event-stream");
require_once 'UsuarioDTO.php';

$counter = rand(1, 10);
while (true) {
    try {
      $curDate = date(DATE_ISO8601);
        $counter--;
    
        if (!$counter) {
            $counter = rand(1, 10);
            $usuario = new UsuarioDTO();
            $usuario->nome = 'Geverson';
            $usuario->sobreNome = 'Souza';
            $usuario->data = $curDate;
            echo 'data: ' . $usuario->getJSONEncode() . "\n\n";
        }
    
        if (ob_get_length()) ob_end_clean();
        
        flush();
    
        if(connection_aborted()) break;
    
        sleep(1);
    } catch (Exception $e) {
        echo 'data: {"erro": "' . $e->getMessage() . '"}\n\n';
    }
}

?>