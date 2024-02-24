<?php
if (empty($_POST)) {
    echo (json_encode(["status" => "error", "message" => "Nenhum argumento foi passado"]));
    exit(0);
}
$success = false;
$com = "";
$message = "";

switch ($action) {
    case 'criar':
        $com = "use sistema;INSERT INTO usuario (";
        $values = "VALUES (";

        foreach ($_POST as $key => $value) {
            $com .= $key . ",";
            $values .= "'" . $value . "',";
        }

        $com = rtrim($com, ",") . ") ";
        $values = rtrim($values, ",") . ");";

        $com .= $values;
        $success = true;
        $message = "Usuário criado com sucesso!";
        break;

    case "modificar":
        $com = "update usuario set ";
        $id = 0;
        foreach (array_combine(array_keys($_POST), array_values($_POST)) as $key => $value) {
            if (strtolower($key) == 'id') {
                $id = $value;
            } else {
                $com .= $key . "='" . $value . "', ";
            }
        }
        $com = substr($com, 0, -2);
        $com .= " where id='" . $id . "';";
        $message = "Usuário modificado com sucesso!";
        break;

    case "logar":
        $com = "select * from usuario where ";
        foreach (array_combine(array_keys($_POST), array_values($_POST)) as $key => $value) {
            $com .= $key . "='" . $value . "' and ";
        }
        $com = substr($com, 0, -5);
        $com .= ";";
        $message = '';
        break;
}

try {
    $rs = $db->prepare($com);
    $rs->execute();
    $numRowsAffected = $rs->rowCount();
    if ($numRowsAffected > 0 || $success != false) {
        $result = $rs->fetchAll(PDO::FETCH_ASSOC);
        echo json_encode(["status" => "success", "message" => $message != "" ? $message : $result]);
    } else {
        echo json_encode(["status" => "error", "message" => "Nenhuma alteração foi feita, verifique a request enviada." ]);
    }
} catch (Exception $ex) {
    $errorInfo = $rs->errorInfo();
    $detailedError = ["SQLState" => $errorInfo[0], "ErrorCode" => $errorInfo[1], "ErrorMessage" => $errorInfo[2]];
    echo json_encode(["status" => "error", "message" => $ex->getMessage(), "errorDetails" => $detailedError]);
}
