import React from "react";
import { Link } from "react-router-dom";
import { Container, Header, Segment, Image, Button } from "semantic-ui-react";

export default function HomePage(){
    return(
        <Segment inverted textAlign='center' vertical className='masthead'>
            <Container text>
                <Header as='h1' inverted>
                    <Image size='massive' src='/assets/logo.jpg' alt='logo' style={{marginBottom: 12}} />
                    Bean Feast
                </Header>
                <Header as='h2' inverted content='Welcome to Bean Feast' />
                <Button as={Link} to='/activities' size='huge' inverted>
                    Take me to the Party!!!
                </Button>
            </Container>
        </Segment>
    )
}