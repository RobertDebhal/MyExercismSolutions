object Bob {
  def response(statement: String): String = {
    if (statement.exists(_.isUpper) && statement.trim.toUpperCase.equals(statement) && statement.endsWith("?"))
      "Calm down, I know what I'm doing!"
    else if (statement.trim.endsWith("?"))
      "Sure."
    else if (statement.exists(_.isUpper) && statement.trim.toUpperCase.equals(statement) && !statement.endsWith("?"))
      "Whoa, chill out!"
    else if (statement.trim.isEmpty)
      "Fine. Be that way!"
    else
      "Whatever."
  }
}
