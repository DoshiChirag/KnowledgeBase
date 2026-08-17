import React, { useState } from "react";
import Container from "./Container";
import Header from "./../wrapper/Header";
import Footer from "./../wrapper/Footer";
//
function Home(){
  const [clicked, setClicked] = useState(false);
  return (
    <div>
      <Header />
      <h2>welcome to the home page</h2>
      <button onClick={() => setClicked(true)}>click me</button>
      {clicked && <div>you clicked the button</div>}
      <Container />
      <Footer />
    </div>
  )
}
//
export default Home
