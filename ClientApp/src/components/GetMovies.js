import React, { useEffect, useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
// import Card from "@material-ui/core/Card";
// import CardActionArea from "@material-ui/core/CardActionArea";
// import CardActions from "@material-ui/core/CardActions";
// import CardContent from "@material-ui/core/CardContent";
// import CardMedia from "@material-ui/core/CardMedia";
// import Button from "@material-ui/core/Button";
// import Typography from "@material-ui/core/Typography";
import MovieDetails from "./MovieDetails";
import {
    Card, CardText, CardBody, CardLink,
    CardTitle, CardSubtitle, CardDeck, CardImg, Button, Row, Col
  } from 'reactstrap';
import "./css/movies.css"

const useStyles = makeStyles({
  root: {
    maxWidth: 345,
  },
  media: {
    height: 140,
  },
}
);

const GetMovies = () => {
  const [movies, setMovies] = useState([]);
  const [id, setId] = useState("0");
  const [status, setStatus] = useState(false);
  const [details, setDetails] = useState([]);
  const [img,setImg]= useState("/src/images/");

  const getMovie = async () => {
    try {
      const response = await fetch(`https://localhost:44324/api/api/`);
      setMovies(await response.json());
    } catch (error) {
      console.log("my error is " + error);
    }
  };
  const getDetail = async () => {
    try {
      const response = await fetch(`https://localhost:44324/api/api/${id}`);
      setDetails(await response.json());
    } catch (error) {
      console.log("my error is " + error);
    }
  };  
  
  useEffect(() => {
    
    if(status == true){
        getDetail();
    }
    else{
      getMovie();
    }
    // console.log(`https://localhost:44324/api/api/${id}`);
    // fetch(`https://localhost:44324/api/api/${id}`)
    //   .then((response) => response.json())
    //   .then((result) => {
    //     setDetails(result);
    //   })
    //   .catch((error) => {
    //     console.log(error);
    //   });
  },[id,status]);

  const showDetails = async (identity) => {
    setId(identity);
    setStatus(true);
    
  };
  const classes = useStyles();

  return (
    <div className="row col-12">
      {status == true ? (
        <MovieDetails id={id} setStatus={setStatus}  details={details} />
      ) : (
        <Row>
          {movies.map((movie) => {
            return (
              
                <Col sm="3">
                 <Card className="card_body">
                 <CardBody>
                         <CardTitle tag="h5" className="cardtitle">{movie.movieName}</CardTitle>
                       </CardBody>
                        <CardImg top width="100%" height="200px" src={require('../../../wwwroot/image/'+movie.image)} alt="Card image cap" className="cardimage"/>
                       <CardBody>
                         <CardText className="cardtext">RELEASE DATE: {movie.realeaseDate} <br/> LANGUAGE: {movie.language}</CardText>
                         <Button onClick={()=>showDetails(movie.movieID)}>Details</Button>
                </CardBody>
                   
                </Card>
                </Col>
             
            );
          })}
        </Row>
      )}
    </div>
  );
};

export {GetMovies};
