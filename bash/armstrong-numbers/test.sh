#! /bin/bash

string="qwerty"
i=0
while [ $i -lt ${#string} ];do
  echo ${string:i:1}
  ((i++))
done
