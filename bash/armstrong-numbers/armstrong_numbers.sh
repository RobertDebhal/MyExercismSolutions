#!/usr/bin/env bash

# This is a bash script template in order to help you quick start any script.
# It contains some sensible defaults, you can learn more by visiting:
# https://google.github.io/styleguide/shell.xml

# This option will make the script exit when there is an error
set -o errexit
# This option will make the script exit when it tries to use an unset variable
set -o nounset

main() {
  # A string variable containing only the FIRST argument passed to the script,
  # you can use input=$@ to get a string with ALL arguments
  
  armstrong_number=0
  num_digits=${#1}
  
  if [ $num_digits -eq 2 ]; then
    echo false
    exit 1
  fi
  
  i=0
  while [ $i -lt $num_digits ]; do
    #assign digit from input number at offset of i to variable 'digit'
    digit=${1:i:1}
    #raise current digit to the power of the number of digits in input number and add to armstrong_number
    armstrong_number=$((digit**num_digits+armstrong_number))
    ((i++))
  done
  
  if [ $armstrong_number -eq $1 ]; then
   echo true
  else
    echo false
    exit 1
  fi
}

# Calls the main function passing all the arguments to it via '$@'
# The argument is in quotes to prevent whitespace issues
main "$@"
