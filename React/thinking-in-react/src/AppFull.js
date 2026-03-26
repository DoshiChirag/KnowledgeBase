import React, { Component, useState } from "react";

function ProductCategoryRow({ category }) {
  return (
    <tr>
      <th colSpan="2">
        {category}
      </th>
    </tr>
  );
}

function ProductRow({ product }) {
  const name = product.stocked ? product.name :
    <span style={{ color: 'red' }}>
      {product.name}
    </span>;

  return (
    <tr>
      <td>{name}</td>
      <td>{product.price}</td>
    </tr>
  );
}

class ProductTable extends React.Component{
    render(){
        const filterText = this.props.filterText;
        const inStockOnly = this.props.inStockOnly;


        const rows = [];
        let lastCategory = null;

        this.props.products.forEach((product) => {
            if(product.name.indexOf(filterText) === -1){
                return;
            }

            if(inStockOnly && !product.stocked){
                return;
            }

            if(product.category != lastCategory){
                rows.push(
                    <ProductCategoryRow 
                        category = {product.category}
                        key = {product.category}
                    />
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
}

function SearchBar({
  filterText,
  inStockOnly,
  onFilterTextChange,
  onInStockChange
}) {
  return (
    <form>
      <input 
        type="text" 
        value={filterText} placeholder="Search..." 
        onChange={(e) => onFilterTextChange(e.target.value)} />
      <label>
        <input 
          type="checkbox" 
          checked={inStockOnly} 
          onChange={(e) => onInStockChange(e.target.checked)} />
        {' '}
        Only show products in stock
      </label>
    </form>
  );
}



class FilterableProductTable extends React.Component{
    constructor(props){
        super(props);

        this.state = {
            filterText: '',
            inStockOnly: false
        }

        this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
        this.handleInStockChange = this.handleInStockChange.bind(this);
    }

    handleFilterTextChange(filterText){
        this.setState({
            filterText : filterText
        });
    }

    handleInStockChange(inStockOnly){
        this.setState({
            inStockOnly: inStockOnly
    });
    }

    render(){
        return(
            <div>
                
                    <SearchBar
                        filterText = {this.state.filterText}
                        inStockOnly = {this.state.inStockOnly}

                        onFilterTextChange = {this.handleFilterTextChange}
                        onInStockChange = {this.handleInStockChange}

                    />

                    <ProductTable 
                        products = {this.props.products}
                        filterText = {this.state.filterText}
                        inStockOnly = {this.state.inStockOnly}
                    />
                
            </div>
        );
    }
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

class AppFull extends Component{
    render(){
        return <FilterableProductTable products={PRODUCTS}/>;
    }
}

//export default AppFull;