#pragma once

#include <QObject>
#include <qbitarray.h>

#include "IOBase.h"

class IOFake : public IOBase
{
	Q_OBJECT

public:
	IOFake(QObject *parent);
	~IOFake();
public slots:
	// Унаследовано через IOBase
	virtual void Start() override;
	virtual void Stop() override;
	virtual void DeInitIO() override;
	virtual bool InitIO();

	virtual int getDOCount() override;
	virtual int getAICount() override;
	virtual int getAOCount() override;
	virtual const QBitArray &getDI() override;
	virtual QBitArray getDO() override;
	virtual bool setDO(QBitArray outputs) override;
	virtual bool setDO(int doChanel, bool value) override;
	virtual double getAI(int aiChannel) override;
	virtual void setAO(int aoChannel, double value) override;
	virtual int getDICount();

private:
	QBitArray _outputs;
	QBitArray _inputs;

	
};
