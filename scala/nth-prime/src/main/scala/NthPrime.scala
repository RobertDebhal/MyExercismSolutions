object NthPrime {

  def prime (n: Int): Option[Int] = {
    def loop(n: Int, primeCount: Int, current: Int): Option[Int] = {
      if (isPrime(current) && primeCount+1==n)
        Some(current)
      else if (isPrime(current) && primeCount+1!=n)
        loop(n,primeCount+1,current+1)
      else
        loop(n,primeCount,current+1)
    }
    if (n==0)
      None
    else
      loop(n,0,2)
  }

  def isPrime (n: Int): Boolean = {
    2.to(n-1).filter(n%_==0).length < 1
  }

}