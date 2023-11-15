import logo from "./logo.svg";
import "./App.css";
import React from "react";
import FilterableUserTable from "./Components/FilterableUserTable";

import Container from "react-bootstrap/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";



function App() {
  const [users, setUsers] = React.useState(null);



  return (
    <div className="App">
      <div className="App-header">
            <h1>Human Resource Information</h1></div>

            <FilterableUserTable  />
    </div>
  );
}

export default App;
