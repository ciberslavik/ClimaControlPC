#pragma once

#include <QObject>


class IOPinBase : public QObject
{
	enum PinType;

	Q_OBJECT
		Q_PROPERTY(PinType Type READ Type WRITE setType);
	
	PinType _pinType;
public:
	enum PinType
	{
		DigitalInput,
		DigitalOutput,
		AnalogInput,
		AnalogOutput
	};
	Q_ENUM(PinType)

	PinType Type() const {
		return _pinType;
	}
void setType(PinType _pinType)
	{

	}
	IOPinBase(QObject *parent);
	~IOPinBase();
public slots:
	
};
