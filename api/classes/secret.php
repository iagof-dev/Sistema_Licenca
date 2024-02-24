<?php

class config{
  private $informations = [
    "db_ip" => "mysql",
    "db_port" => "3306",
    "db_user" => "root",
    "db_pass" => "132490Kj@br=",
  ];

  function get(){
    return $this->informations;
  }
}
