import {  BrowserRouter,  Route, Routes, Link} from "react-router-dom" ;
import Home from "./components/home/Home";
import Employees from './components/employees/Employees';
import './styles.css';
//
function App() {
  return (
    <div>
      <BrowserRouter>
        <Routes>
            <Route exact path="/" element =  {<Home />}/>
            <Route path="/employees" element={<Employees />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}
//
export default App;
