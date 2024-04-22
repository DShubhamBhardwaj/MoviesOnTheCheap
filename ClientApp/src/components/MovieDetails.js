import React, { useEffect, useState } from 'react'
import { Container, Row, Col } from 'reactstrap';
import "./css/detail.css"


const MovieDetails = (props) =>{
   
    
    {console.log(typeof(props.details.image))}
     const {image} =props.details;
     {console.log({image});}
     const [img,setImg] = useState();
     

    const changestate =() =>{
        props.setStatus(false);
    }
    return (
        <Container className="detailsContainer">
            <div className="row col-sm-12 border-darken-1">
                <div className="col-sm-8">
                    <div>
                        <h1 className="detailsTitle">{props.details.movieName}</h1>
                        <p className="descripton">{props.details.description} </p> <hr/>
                        <span className="sideHeading">LANGUAGE :     </span> {props.details.language}<br/>
                        <span className="sideHeading">RELEASE DATE : </span>{props.details.realeaseDate}<br/>
                        <span className="sideHeading"> PRODUCER :    </span>{props.details.producersName}<br/>
                        <span className="sideHeading">DIRECTOR :     </span> {props.details.directorName}<br/>
                        <span className="sideHeading">Movie Cast :     </span> {props.details.movieCasts}<br/>
                        <span className="sideHeading">Movie Categories :     </span> {props.details.movieGenre}<br/>
                        <hr/>
                        
                    </div>
                </div>
                <div className="col-sm-4">
                    <div>
                        {image!== undefined? (<img src={require('../images/'+image)} alt="Movie Image" style={{textAlign:'center'}}/>) : ""}
                    </div>
                    <button className="btn-primary backButton" onClick={() => changestate() }>BACK TO LIST OF MOVIES</button>
                </div>
                
            </div>
        </Container>
        
        
    )
}

export default MovieDetails;