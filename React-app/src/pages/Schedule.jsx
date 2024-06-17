import React from 'react'
import Navigation from './Nav/Navigation'
import { useNavigate } from 'react-router-dom';
import "./css/Schedule.css"

function Schedule() {
  const navigate = useNavigate();

  const redirect = (path) => {
    navigate(path);
  };
  return (
    <>
    <div className='TT'>
      <div className='TT_Container'>
          <div style={{ flexShrink: 0, position: 'absolute', top: '15%', left: 0 }}>
            <Navigation />
          </div>        
      </div>
      <div className='TopPanelBody'>
        <div className='EventNewsBody' id="EventBody">
          <div className='VminText'>События</div>
        </div>
        <button className='NameBody' onClick={() => redirect('/profile')}>
          <div className='VminText'>H.H</div>
        </button>
        <div className='EventNewsBody' id="NewsBody">
          <div className='VminText'>Новости</div>
        </div>
      </div>
      <div className='CalendarBody'>
        <div className="calendar">
          <div className="month">June 2024</div>
          <div className="days">
              <div className="day">S</div>
              <div className="day">M</div>
              <div className="day">T</div>
              <div className="day">W</div>
              <div className="day">T</div>
              <div className="day">F</div>
              <div className="day">S</div>
          </div>
          
        </div>        
      </div>
    
    </div>
    </>
  )
}  

export default Schedule