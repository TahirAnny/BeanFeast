import React from 'react';
import { Button, Container, Menu } from 'semantic-ui-react';

export default function NavBar(){
    return(
        <Menu inverted fixed="top">
            <Container>
                <Menu.Item header>
                    <img src="assets/logo.jpg" alt="logo" style={{marginRight: '10px'}} />
                    Bean Feast
                </Menu.Item>
                <Menu.Item name="Activities" />
                <Menu.Item>
                    <Button positive content='Create Activity'></Button>
                </Menu.Item>
            </Container>
        </Menu>
    )
}