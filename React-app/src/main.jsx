import React from 'react'
import ReactDOM from 'react-dom/client'

import App from './App.jsx'
import Login from './pages/login.jsx'
import NotFound from './pages/NotFound.jsx'
import Profile from './pages/profile.jsx'
import HomeWork from './pages/HomeWork.jsx'
import Other from './pages/Other.jsx'
import Grades from './pages/Grades.jsx'
import Schedule from './pages/Schedule.jsx'

import './pages/css/index.css'


import { createBrowserRouter, RouterProvider } from 'react-router-dom'


const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
    errorElement: <NotFound/>
  },
  {
    path: "login",
    element: <Login/>
  },
  {
    path: "profile",
    element: <Profile/>
  },
  {
    path: "hw",
    element: <HomeWork/>
  },
  {
    path: "other",
    element: <Other/>
  },
  {
    path: "grades",
    element: <Grades/>
  },
  {
    path: "schedule",
    element: <Schedule/>
  },
])

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router}/>
  </React.StrictMode>,
)
