import React from 'react'
import Navigation from './Nav/Navigation'
import "./css/TimeTable.css"

function Schedule() {
  return (
    <>
    <div className='TT'>
      <div className='TT_Container'>
          <div style={{ flexShrink: 0, position: 'absolute', top: '15%', left: 0 }}>
            <Navigation />
          </div>        
      </div>
      <div className='TopPanelBody'>
        <button className='EventNewsBody' id="EventBody">
          <div className='VminText'>События</div>
        </button>
        <button className='NameBody'>
          <div className='VminText'>H.H</div>
        </button>
        <div className='EventNewsBody' id="NewsBody">
          <div className='VminText'>Новости</div>
        </div>
      </div>
      <div className='NewsContainer'>
        <div className="card">
          <div className="card-content">
              <h3 className="card-title">Заголовок</h3>
              <p className="card-text">Текст</p>
              <a href="#" className="card-link">Подробнее</a>
              
          </div>
          
        </div>        
      </div>
    
    </div>
    </>
  )
}  

export default Schedule