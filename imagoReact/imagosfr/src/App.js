import React, { Component } from 'react';
import './App.css';
import img from './img/1.jpg'

class Listagem extends Component{
  constructor(props){
    super(props);
    this.state = {
      listagem: []
    }
    this.buscarListagem = this.buscarListagem.bind(this);
  }

 
  componentDidMount(){
    this.buscarListagem();
  }

  buscarListagem(){
    fetch('https://localhost:5001/api/imagos').
    then(resp => resp.json()).
    then(data => {this.setState({listagem : data})}).catch((erro) => console.log(erro))
  }



render(){  
  return (
    <div className="App">
      <body>
        <main style={{height:"100%", width:"100%", 
        display:"flex", justifyContent:"center"}}>

          {this.state.listagem.map( item => {
            return(
          <div style={{height:"300px",
          width:"300px", backgroundColor:"gray",
          display:"flex", justifyContent:"center",
          flexDirection:"column-reverse", alignItems:"center", margin:"0.4em"}}>

            <textarea style={{color:"black", 
            fontSize:"1em", margin:"0.7em"}}>{item.description}</textarea>
            <img style={{width:"120px", height:"120px"}} 
            src={"https://localhost:5001/arch/"+item.imagego}></img>

          </div>
            )})}

        </main>
      </body>
    </div>
  );
}
}
export default Listagem;
