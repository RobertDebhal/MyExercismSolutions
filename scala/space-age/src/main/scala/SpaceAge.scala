object SpaceAge {
  def onEarth(age: Double) :Double = {
    round(age/31557600,2)
  }

  def onMercury(age: Double) :Double = {
    round(onEarth(age)/0.2408467,2)
  }

  def onVenus(age: Double) :Double = {
    round(onEarth(age)/0.61519726,2)
  }

  def onMars(age: Double) :Double = {
    round(onEarth(age)/1.8808158,2)
  }

  def onJupiter(age: Double) :Double = {
    round(onEarth(age)/11.862615,2)
  }

  def onSaturn(age: Double) :Double = {
    round(onEarth(age)/29.447498,2)
  }

  def onUranus(age: Double) :Double = {
    round(onEarth(age)/84.016846,2)
  }

  def onNeptune(age: Double) :Double = {
    round(onEarth(age)/164.79132,2)
  }

  def round(num: Double, precision: Int) :Double = {
    val scale = scala.math.pow(10,precision)
    (num*scale).round/scale
  }

}
