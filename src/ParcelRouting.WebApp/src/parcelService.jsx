import React, { useState } from 'react'
import Parcel from './Parcel'
import Department from './Department'

const Container = () => {
  {
    const [parcels, setParcels] = useState([
      {
        id: 1,
        text: 'Schenklaan 22, 2497AV, Den Haag',
        weight: 0.02,
        declaredValue: 0.0,
        isSignedOff: false,
        currentDepartment: ''
      },
      {
        id: 2,
        text: 'Korenbloemkamp 22, 2353HS, Leiderdorp',
        weight: 2.0,
        declaredValue: 0.0,
        isSignedOff: false,
        currentDepartment: ''
      },
      {
        id: 3,
        text: 'Burgemeester Roosstraat 33, 3035AC, Rotterdam',
        weight: 100.0,
        declaredValue: 2000.0,
        isSignedOff: false,
        currentDepartment: ''
      },
      {
        id: 4,
        text: 'Burgemeester Roosstraat 33, 3035AC, Rotterdam',
        weight: 11,
        declaredValue: 500,
        isSignedOff: false,
        currentDepartment: ''
      }
    ])

    const [departments, setDepartments] = useState([
      {
        name: "Insurance",
        description: "(declared value above 1000)",
        acceptsDeclaredValue: (declaredValue, isSignedOff) => declaredValue > 1000,
        acceptsWeight: (weight) => true,
        process: (signOff) => { signOff() }
      },
      {
        name: "Mail",
        description: "(weight below 1kg)",
        acceptsDeclaredValue: (declaredValue, isSignedOff) => declaredValue <= 1000 || (declaredValue > 1000 && isSignedOff),
        acceptsWeight: (weight) => weight <= 1,
        process: (signOff) => { }
      },
      {
        name: "Regular",
        description: "(weight up to 10kg)",
        acceptsDeclaredValue: (declaredValue, isSignedOff) => declaredValue <= 1000 || (declaredValue > 1000 && isSignedOff),
        acceptsWeight: (weight) => weight > 1 && weight <= 10,
        process: (signOff) => { }
      },
      {
        name: "Heavy",
        description: "(weight above 10kg)",
        acceptsDeclaredValue: (declaredValue, isSignedOff) => declaredValue <= 1000 || (declaredValue > 1000 && isSignedOff),
        acceptsWeight: (weight) => weight > 10,
        process: (signOff) => { }
      }
    ]);

    return (
      <div> 
        <div style={{ overflow: 'hidden', clear: 'both' }}>
          {departments.map((department, i) => (
            <Department 
              key={department.name}
              name={department.name} 
              description={department.description}
              acceptsDeclaredValue={department.acceptsDeclaredValue} 
              acceptsWeight={department.acceptsWeight}
              process={department.process} />
          ))}
        </div>

        <div style={{ width: 400, overflow: 'hidden', clear: 'both' }}>
          {parcels.map((parcel, i) => (
            <Parcel
              key={parcel.id}
              index={i}
              id={parcel.id}
              text={parcel.text}
              weight={parcel.weight}
              declaredValue={parcel.declaredValue}
              currentDepartment={parcel.currentDepartment}
              isSignedOff={parcel.isSignedOff}
              signOff={() => parcel.isSignedOff = true }
              moveTo={(name) => { 
                parcel.currentDepartment = name;
                setParcels(parcels.map(p => { return p; }));
              }}
            />
          ))}
        </div>
      </div> 
    )
  }
}
export default Container
