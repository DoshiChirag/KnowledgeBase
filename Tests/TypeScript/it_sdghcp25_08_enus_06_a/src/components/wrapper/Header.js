import logo from './../../chart.gif';
function Header(){
  return (
    <header>
      <img src={logo} id="logo" alt="logo"/>
      <h1><a href="index.html">Skillsoft Weight Tracker</a></h1>
      <nav>
        <ul>
          <li><a href="index.html">home</a></li>
          <li><a href="enterweight.html">enter weight</a></li>
          <li><a href="myweights.html">my weight</a></li>
          <li><a href="teamweights.html">team weights</a></li>
        </ul>
      </nav>
    </header>    
  )
}
//
export default Header
