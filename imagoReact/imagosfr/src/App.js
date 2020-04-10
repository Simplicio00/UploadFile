import React, { Component } from 'react';
import './App.css';
import img from './img/1.jpg'

class Listagem extends Component{
  constructor(props){
    super(props);
    this.state = {
      listagem: [],
      description: '',
      imagego: React.createRef()
    }
    this.buscarListagem = this.buscarListagem.bind(this);
    this.cadastrar = this.cadastrar.bind(this);
    this.atualizaDescricao = this.atualizaDescricao.bind(this);
  }

  atualizaDescricao(event){
    this.setState({description:event.target.value})
  }

  cadastrar (event){
    let cad = new FormData();
    cad.set("description", this.state.description);
    cad.set("imagego", this.state.imagego.current.files[0]);

    event.preventDefault();
    fetch('https://localhost:5001/api/imagos', {
      method:'POST',
      body:cad
    })
    .then(resp => resp.json().then(window.location.reload()))
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
        display:"flex", flexDirection:"column", alignItems:"flex-start"}}>
          <div style={{width:"900px", height:"100%", display:"flex",flexDirection:"row",margin:"1em"}}>
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
          </div>

            <div style={{width:"500px", height:"300px", border:"solid 1px",borderColor:"red", 
            display:"flex", alignItems:"center", justifyContent:"center"}}>


              <form onSubmit={this.cadastrar}>

                <label>Dê uma descrição</label>
                <input required type="text" value={this.state.description} onChange={this.atualizaDescricao} />
                <br></br>
                <br></br>
                <label>Selecione uma imagem</label>
                <br></br>
                <input required ref={this.state.imagego} type='file'/>
                <button type="submit">Cadastrar</button>

              </form>


            </div>
        </main>
      </body>
    </div>
  );
}
}
export default Listagem;
