#pragma once

#include <QObject>
#include <QBitArray>

class IOBase :public QObject
{
	
	Q_OBJECT
public:
	~IOBase();
public slots:
	virtual bool InitIO() = 0;
	virtual void Start() = 0;
	virtual void Stop() = 0;
	virtual void DeInitIO() = 0;
	virtual int getDICount() = 0;
	virtual int getDOCount() = 0;
	virtual int getAICount() = 0;
	virtual int getAOCount() = 0;

	virtual const QBitArray &getDI() = 0;

	virtual QBitArray getDO() = 0;
	virtual bool setDO(QBitArray outputs) = 0;
	virtual bool setDO(int doChanel, bool value) = 0;
	virtual double getAI(int aiChannel) = 0;
	virtual void setAO(int aoChannel, double value) = 0;


signals:
	void Fault(QString *msg);
	void DIChanged(int diChannel, bool state);
protected:
	IOBase(QObject* parent);
};
