import { Component } from "react";
//
class Main extends Component{
  constructor(props){
    super(props);
    this.state = {
      allEmployees: []
    }
  }
  componentDidMount(){
    fetch("http://localhost:3030/employees")
    .then(data => {
      return data.json();
    })
    .then(resolvedData=>{
      this.setState({
        allEmployees:resolvedData
      });
    });
  }
  render(){
    return (
      <main>
        <h2>Employees List</h2>
        { 
          this.state.allEmployees.map( (customer,index) => (
            <div key={index}>
              {customer.username}&nbsp;
              {customer.password}            
            </div>
          ) ) 
        }
      </main>  
    )  
  }
}
//
export default Main