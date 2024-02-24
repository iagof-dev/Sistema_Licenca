<?php
switch ($action) {
    case 'id':
        $rs = $db->prepare("SELECT id, username, expiration FROM usuario where id={$param};");
        break;
    case 'name':
        $rs = $db->prepare("SELECT id, username, expiration FROM usuario where username='{$param}';");
        break;
    default:
        $rs = $db->prepare("SELECT id, username, expiration FROM usuario;");
        break;
}
$rs->execute();
$obj = $rs->fetchAll(PDO::FETCH_ASSOC);


if(empty($obj)){
    echo json_encode(["status" => "error","DATA" => "Usuário inexistente!"]);
}
else{
    echo json_encode(["status" => "success","DATA" => $obj]);
}




?>