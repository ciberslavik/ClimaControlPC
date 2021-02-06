#include "IOFake.h"

IOFake::IOFake(QObject *parent)
	: IOBase(parent),
	_inputs(16),
	_outputs(16)
{

}

IOFake::~IOFake()
{
}

int IOFake::getDOCount()
{
	return _outputs.size();
}

int IOFake::getAICount()
{
	return 0;
}

int IOFake::getAOCount()
{
	return 0;
}

const QBitArray &IOFake::getDI()
{
	return _inputs;
}

QBitArray IOFake::getDO()
{
	return _outputs;
}

bool IOFake::setDO(QBitArray outputs)
{
	return false;
}

bool IOFake::setDO(int doChanel, bool value)
{
	return false;
}

double IOFake::getAI(int aiChannel)
{
	return 0.0;
}

void IOFake::setAO(int aoChannel, double value)
{
}

int IOFake::getDICount()
{
	return 0;
}

void IOFake::Start()
{
}

void IOFake::Stop()
{
}

void IOFake::DeInitIO()
{
}

bool IOFake::InitIO()
{
	_inputs.resize(20);
	_outputs.resize(20);

	return false;
}
