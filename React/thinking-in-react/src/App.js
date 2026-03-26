import React, { Component, useState, useContext, useEffect } from "react";
import './App.css'

const AppContext = React.createContext()

const ProductCategoryRow = (value) =>{  
    const context = useContext(AppContext); 
    const prodcategories = context.categoryList;   
    //alert("Category Value ="+ value.toString());
    return (
    <tr>
      <th colSpan="2">
        {prodcategories[prodcategories.length-1]}
      </th>
    </tr>
  );
}

class ProductRow extends React.Component{
   
    render(){
     const prodname = this.props.product.name;
     const prodprice = this.props.product.price;
     const name = this.props.product.stocked ? prodname :
    <span style={{ color: 'red' }}>
      {prodname}
    </span>;
    
    return ( 
    <tr>
      <td>{name}</td>
      <td>{prodprice}</td>
    </tr>
  );
}
}

function ProductTable(){
    
        const context = useContext(AppContext);
        const filterText = context.filterText;
        const inStockOnly = context.inStockOnly;
        const products = context.products;
        const categoryList = context.categoryList


        const rows = [];
        let lastCategory = null;
        let index = -1;
        products.PRODUCTS.forEach((product) => {
            if(product.name.indexOf(filterText) === -1){
                return;
            }

            if(inStockOnly && !product.stocked){
                return;
            }

            if(product.category !== lastCategory){
                categoryList.push([product.category])
                index++;                  
                rows.push(
                    <ProductCategoryRow value={index.toString()} key={index.toString()} />
                );
            
            }


            rows.push(
                <ProductRow 
                    product = {product}
                    key = {product.name}
                />
            );

            lastCategory = product.category;
        });

return(
    <table>
        <thead>
            <tr>
                <th>Name</th>
                <th>Price</th>
            </tr>
        </thead>
        <tbody>{rows}</tbody>
    </table>

);

    
}

const SearchBar = () => {
    const context  = useContext(AppContext)
    const [theTime, setTheTime] = useState(new Date())
    useEffect(() => {
        const ticker = setInterval(() => seizeTheTime(), 1000);
        return function cleanup(){
            clearInterval(ticker);
        }
    })
    function seizeTheTime(){
        setTheTime(new Date())
    }
    return (
    <React.Fragment>
        <div className = "theThinkingClock">
            <h4>Welcome back!</h4>
            <h5>It is {(typeof theTime !== 'undefined' && theTime !== null) ? theTime.toLocaleTimeString(): 'time to go'} </h5>
        </div>
        <form>      
             <input 
                type="text" 
                value={context.filterText} placeholder="Search..." 
                onChange={(e) => context.handleFilterTextChange(e.target.value)} />
            <p>
            <input 
                type="checkbox" 
                checked={context.inStockOnly} 
                onChange={(e) => context.handleInStockChange(e.target.checked)} />
                {' '}
                Only show products in stock
             </p>
        </form>
    </React.Fragment>
    );
}
   
  





const ProductTableProvider = (props) => {
    const [filterText, setFilterText] = useState('')
    const [inStockOnly, setInStockOnly] = useState(false)
    const [categoryList, setCategoryList] = useState([])
     
    const [products] = useState(PRODUCTS)
     const state = {
            filterText: '',
            inStockOnly: false,
            products : {PRODUCTS},
            categoryList : [],            
            handleFilterTextChange : (filterText) => {
                    this.setState({filterText : filterText})
                },
            handleInStockChange : (inStockOnly) => {
                    this.setState({inStockOnly: inStockOnly})
                }
  
            };  
    
    
        return(
            <AppContext.Provider value={state}>
                <div>
                    {props.children}                
                </div>                
            </AppContext.Provider>
        );
    
}

const PRODUCTS = [
  {category: "Sporting Goods", price: "$49.99", stocked: true, name: "Football"},
  {category: "Sporting Goods", price: "$9.99", stocked: true, name: "Baseball"},  
  {category: "Sporting Goods", price: "$29.99", stocked: false, name: "Basketball"},
  {category: "Electronics", price: "$99.99", stocked: true, name: "iPod Touch"},
  {category: "Electronics", price: "$199.99", stocked: true, name: "Nexus 7"},
  {category: "Electronics", price: "$399.99", stocked: false, name: "iPhone 5"},
  {category: "Fruits", price: "$1", stocked: true, name: "Apple"},
  {category: "Fruits", price: "$1", stocked: true, name: "Dragonfruit"},
  {category: "Fruits", price: "$2", stocked: false, name: "Passionfruit"},
  {category: "Vegetables", price: "$2", stocked: true, name: "Spinach"},
  {category: "Vegetables", price: "$4", stocked: false, name: "Pumpkin"},
  {category: "Vegetables", price: "$1", stocked: true, name: "Peas"}
];

class App extends Component{
    componentDidMount() {
    console.log('I was triggered during componentDidMount')
    }
    render(){
        console.log('I was triggered during render')
        return (
            <ProductTableProvider>
                <SearchBar />                
                <ProductTable/>                
            </ProductTableProvider>
        );
    }
}

export default App;