object SumOfMultiples {
  def sum(factors: Set[Int], limit: Int): Int = {
    0.to(limit-1).filter(x => factors.exists(y => x%y == 0)).sum
}
}

