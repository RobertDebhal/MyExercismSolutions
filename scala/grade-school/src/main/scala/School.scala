import scala.collection.immutable.ListMap

class School {
  type DB = Map[Int, Seq[String]]

  var schoolDB: DB = Map()

  def db: DB = schoolDB

  def add(name: String, g: Int)  = {
      schoolDB = schoolDB + (g -> List.concat(schoolDB.getOrElse(g,List()),List(name)))
  }

  def grade(g: Int): Seq[String] = {
    this.db.getOrElse(g,Seq())
  }

  def sorted: DB = {
    this.db.toSeq.sortBy(x => x._1).map(x => (x._1, x._2.sorted)).toMap
  }
}