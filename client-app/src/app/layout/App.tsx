import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container, Header, List } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';

function App() {

  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);


  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5001/api/activities').then(response => {
      setActivities(response.data);
    })
  }, [])

  function handleSelectedActivity(id: string){
    setSelectedActivity(activities.find(x=>x.id === id))
  }

  function handleCancleSelectActivity(){
    setSelectedActivity(undefined);
  }

  function handleFormOpen(id?: string){
    id ? handleSelectedActivity(id) : handleCancleSelectActivity();
    setEditMode(true);
  }

  function handleFormClose(){
    setEditMode(false);
  }

  return (
    <> {/*shortcut version of using Fragment*/}
      <NavBar openForm = {handleFormOpen} />
      <Container style={{marginTop: '7em'}}>
          <ActivityDashboard
           activities = {activities} 
           selectedActivity = {selectedActivity}
           selectActivity = {handleSelectedActivity}
           cancelSelectActivity = {handleCancleSelectActivity}
           editMode = {editMode}
           openForm = {handleFormOpen}
           closeForm = {handleFormClose}
          />
      </Container>
    </>
  );
}

export default App;
